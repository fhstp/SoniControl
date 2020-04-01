/*
 * Copyright (c) 2020. Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
 *
 * This file is part of SoniControl server.
 *
 *     SoniControl server is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     SoniControl server is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with SoniControl server.  If not, see <http://www.gnu.org/licenses/>.
 */

import models from "../models";
import mongoose = require("mongoose");

export class DetectionController {

    public getAllDetections(): any {
        return models.Detection.find({}).then((detections) => {
            return detections;
        });
    }

    public getSpecificTechnologyDetections(): any {
        return models.Detection.find({}).then((detections) => {
            return detections;
        });
    }

    public getFullFilteredDetections(data): any {
        const NO_VALUES_ENTERED = -10000.0;
        const ALL_TECHNOLOGIES = "-10";

        const longitude = data.longitude;
        const latitude = data.latitude;
        const technology = data.technologyid;
        const spoofDecisions = [0, 1];
        let timestampfrom;
        let timestampto;
        let range: number;

        if (parseInt(data.range, 10) === 0) {
            range = 1;
        } else if (parseInt(data.range, 10) === undefined || parseInt(data.range, 10) === null ||
            data.range === "" || data.range <= NO_VALUES_ENTERED) {
            range = 40075000;
        } else {
            range = parseInt(data.range, 10);
        }
        if (data.timestampfrom === undefined || data.timestampfrom === null) {
            timestampfrom = new Date("2019-01-01T00:00:00.000Z");
        } else {
            timestampfrom = new Date(data.timestampfrom);
        }
        if (data.timestampto === undefined || data.timestampfrom === null) {
            timestampto = new Date();
        } else {
            timestampto = new Date(data.timestampto);
        }
        if (longitude === undefined || latitude === undefined || longitude === null || latitude === null ||
             longitude <= NO_VALUES_ENTERED || latitude <= NO_VALUES_ENTERED ) {
            if (technology === ALL_TECHNOLOGIES) {
                return models.Detection.find({
                    spoofDecision: {$in: spoofDecisions},
                    timestamp: {$gt: timestampfrom, $lt: timestampto}
                }).then((detections) => {
                    return detections;
                });
            } else {
                return models.Detection.find({
                    technologyid:  {$in: technology},
                    spoofDecision: {$in: spoofDecisions},
                    timestamp: {$gt: timestampfrom, $lt: timestampto}
                }).then((detections) => {
                    return detections;
                });
            }
        } else if (technology === ALL_TECHNOLOGIES) {
            return models.Detection.find({
                location: {
                    $near: {
                        $maxDistance: range,
                        $geometry: {
                        type: "Point",
                        coordinates: [longitude, latitude]
                        }
                    }
                },
                timestamp: {$gt: timestampfrom, $lt: timestampto}
            }).then((detections) => {
                return detections;
            });
        } else {
            return models.Detection.find({
                location: {
                    $near: {
                        $maxDistance: range,
                        $geometry: {
                        type: "Point",
                        coordinates: [longitude, latitude]
                        }
                    }
                },
                technologyid:  {$in: technology},
                timestamp: {$gt: timestampfrom, $lt: timestampto}
            }).then((detections) => {
                return detections;
            });
        }
    }

    public async groupDetections(detections): Promise<any> {
        let detectionList = [];
        let amplitudeMin = 100;
        let amplitudeMax = 0;
        for (let d in detections) {
            if (detections[d].amplitude > amplitudeMax) {
                amplitudeMax = detections[d].amplitude;
            }
            if (detections[d].amplitude < amplitudeMin) {
                amplitudeMin = detections[d].amplitude;
            }
            if (detectionList.length === 0) {
                detectionList.push({detection: detections[d], count: 1, technologyid: [detections[d].technologyid],
                     technology: [detections[d].technology]});
            } else {
                let isAlreadyDetected = false;
                let detected = null;
                for (let dl in detectionList) {
                    if (this.isDetectionEquivalent(detectionList[dl], detections[d])) {
                        isAlreadyDetected = true;
                        detected = dl;
                        break;
                    }
                }
                if (isAlreadyDetected) {
                    if (!this.isTechnologyAlreadyIn(detectionList[detected], detections[d])) {
                        detectionList[detected].technologyid.push(detections[d].technologyid);
                        detectionList[detected].technology.push(detections[d].technology);
                    }
                    detectionList[detected].count = detectionList[detected].count + 1;
                    detectionList[detected].detection.timestamp = detections[d].timestamp;
                    detectionList[detected].detection.amplitude = detections[d].amplitude;
                } else {
                    detectionList.push({detection: detections[d], count: 1, technologyid: [detections[d].technologyid],
                        technology: [detections[d].technology]});
                }
            }
        }
        let detectionInfos = {detectionList: detectionList, amplitudeMax: amplitudeMax, amplitudeMin: amplitudeMin};
        return await detectionInfos;
    }

    private isDetectionEquivalent(detectionListItem, detection) {
        
        if (this.calculateDistance(detectionListItem.detection.location.coordinates,
            detection.location.coordinates) * 1000 <= 10) {
            return true;
        }

        return false;
    }

    private isTechnologyAlreadyIn(detectionListItem, detection) {
        for (let techId in detectionListItem.technologyid) {
            if (detectionListItem.technologyid[techId] === detection.technologyid) {
                return true;
            }
        }
        return false;
    }

    private calculateDistance(location1, location2) {
        let R = 6371; // Radius of the earth in km
        let dLat = this.deg2rad(location2[1] - location1[1]);  // deg2rad below
        let dLon = this.deg2rad(location2[0] - location1[0]);
        let a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(this.deg2rad(location1[1])) * Math.cos(this.deg2rad(location2[1])) *
          Math.sin(dLon / 2) * Math.sin(dLon / 2);
        let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        let d = R * c; // Distance in km
        return d;
      }

      private deg2rad(deg) {
        return deg * (Math.PI / 180);
      }
}
