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

export class DataFactory {
    public static getInstance(): DataFactory {
        if (DataFactory.instance === null || DataFactory.instance === undefined) {
            DataFactory.instance = new DataFactory();
        }

        return DataFactory.instance;
    }

    private static instance: DataFactory;
    private colTechnologies: any;

    private constructor() {
    }

    public async createData() {
        const db = mongoose.connection;
        this.initTechnologies(db);
    }

    public async initTechnologies(db) {
        const unknown = new models.Technology({
            technologyid: "0",
            name: "Unknown",
        });

        const googlenearby = new models.Technology({
            technologyid: "1",
            name: "Google Nearby",
        });

        const prontoly = new models.Technology({
            technologyid: "2",
            name: "Prontoly",
        });

        const sonarax = new models.Technology({
            technologyid: "3",
            name: "Sonarax",
        });

        const signal360 = new models.Technology({
            technologyid: "4",
            name: "Signal 360",
        });

        const shopkick = new models.Technology({
            technologyid: "5",
            name: "Shopkick",
        });

        const silverpush = new models.Technology({
            technologyid: "6",
            name: "Silverpush",
        });

        const lisnr = new models.Technology({
            technologyid: "7",
            name: "Lisnr",
        });

        const sonitalk = new models.Technology({
            technologyid: "8",
            name: "SoniTalk",
        });

        models.Technology.countDocuments({
            technologyid: "0", name: "Unknown"}).then((count) => {
                if (count === 0) {
                    unknown.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "1", name: "Google Nearby"}).then((count) => {
                if (count === 0) {
                    googlenearby.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "2", name: "Prontoly"}).then((count) => {
                if (count === 0) {
                    prontoly.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "3", name: "Sonarax"}).then((count) => {
                if (count === 0) {
                    sonarax.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "4", name: "Signal 360"}).then((count) => {
                if (count === 0) {
                    signal360.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "5", name: "Shopkick"}).then((count) => {
                if (count === 0) {
                    shopkick.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "6", name: "Silverpush"}).then((count) => {
                if (count === 0) {
                    silverpush.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "7", name: "Lisnr"}).then((count) => {
                if (count === 0) {
                    lisnr.save();
                }
            });

        models.Technology.countDocuments({
            technologyid: "8", name: "SoniTalk"}).then((count) => {
                if (count === 0) {
                    sonitalk.save();
                }
            });
    }
}
