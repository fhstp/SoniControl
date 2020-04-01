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

import * as IO from "socket.io";
import * as IOClient from "socket.io-client";
import {DetectionController} from "../controller/detectionController";
import {TechnologyController} from "../controller/technologyController";
import * as Geocoder from "node-open-geocoder";

export class Socket {
    private socket: any;
    private webClientsocket: any;
    private detectionController: DetectionController;
    private technologyController: TechnologyController;
    private geocoderOptions: any;
    private geocoder: Geocoder;

    constructor(server: any) {
        this.socket = new IO(server);
        this.detectionController = new DetectionController();
        this.technologyController = new TechnologyController();
        this.attachListeners();
        this.geocoder = new Geocoder(this.geocoderOptions);
    }

    private attachListeners(): void {
        this.socket.on("connection", (socket) => {
            socket.emit("connected", "Client Table connected to Server!");

            socket.on("connectClient", () => {
                this.webClientsocket = socket.id;
                socket.emit("connectClientResult", "SUCCESS");
            });

            socket.on("requestMarkers", () => {
                this.detectionController.getAllDetections().then((detections) => {
                    this.detectionController.groupDetections(detections).then((groupedDetections) => {
                        this.technologyController.getAllTechnologies().then((technologies) => {
                            const markerData = {detectionList: groupedDetections.detectionList,
                                technologyList: technologies,
                                amplitudeMax: groupedDetections.amplitudeMax,
                                amplitudeMin: groupedDetections.amplitudeMin
                            };
                            socket.emit("sendMarkerData", markerData);
                        });
                    });
                });
            });

            socket.on("sendFilterSpecs", (data) => {
                if (data.location === undefined || data.location === null) {
                    const dataUpdate = {longitude: undefined, latitude: undefined, technologyid: data.technology,
                            timestampfrom: data.datetimefrom, timestampto: data.datetimeto, range: data.range};
                    this.detectionController.getFullFilteredDetections(dataUpdate).then((detections) => {
                        this.detectionController.groupDetections(detections).then((groupedDetections) => {
                            this.technologyController.getAllTechnologies().then((technologies) => {
                                const markerData = {detectionList: groupedDetections.detectionList,
                                    technologyList: technologies,
                                    amplitudeMax: groupedDetections.amplitudeMax,
                                    amplitudeMin: groupedDetections.amplitudeMin
                                };
                                socket.emit("reloadMarker", markerData);
                            });
                        });
                    });
                } else {
                    this.geocoder.geocode(data.location).end((err, res) => {
                        const dataUpdate = {longitude: res[0].lon, latitude: res[0].lat, technologyid: data.technology,
                            timestampfrom: data.datetimefrom, timestampto: data.datetimeto, range: data.range};
                        this.detectionController.getFullFilteredDetections(dataUpdate).then((detections) => {
                            this.detectionController.groupDetections(detections).then((groupedDetections) => {
                                this.technologyController.getAllTechnologies().then((technologies) => {
                                    const markerData = {detectionList: groupedDetections.detectionList,
                                        technologyList: technologies,
                                        amplitudeMax: groupedDetections.amplitudeMax,
                                        amplitudeMin: groupedDetections.amplitudeMin
                                    };
                                    socket.emit("reloadMarker", markerData);
                                });
                            });
                        });
                    });
                }
            });
        });
    }
}
