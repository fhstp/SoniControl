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

import * as bodyParser from "body-parser";
import * as Express from "express";
import * as http from "http";
import { Connection } from "../database";
import uuidv4 = require("uuid/v4");
import models from "../models";
import { DataFactory } from "../database/dataFactory";
import fs = require("fs");
import multer = require("multer");
import sftpStorage = require("multer-sftp");
import { Socket } from "../websockets";
import { DetectionController } from "../controller";
import { TechnologyController } from "../controller";
import * as mkdirp from "mkdirp";
require("dotenv").config();

export default class Server {
    private server: any;
    private app: any;
    private database: any;
    private socket: Socket;
    private detectionController: DetectionController;
    private technologyController: TechnologyController;

    constructor() {
        this.app = Express();
        this.server = new http.Server(this.app);
        this.database = Connection.getInstance();
        this.socket = new Socket(this.server);

        this.detectionController = new DetectionController();
        this.technologyController = new TechnologyController();

        const upload = multer();

        const Client = require("ssh2-sftp-client");
        let sftp = new Client();

        this.app.use(require("body-parser").urlencoded({extended : true}));
        this.app.use(require("body-parser").json());

        this.app.use(require("body-parser").json({ limit: "5mb" }));
        this.app.use(require("body-parser").raw({ type: "audio/wav", limit: "5mb" }));

        this.app.use((req, res, next) => {
            req.context = {
              models,
              me: models.Detection[1],
            };
            next();
        });

        this.database.connectDb().then(async (connection) => {
            this.server.listen(process.env.PORT, () => {
                const dir = process.env.ROOT + process.env.NODE_PATH + "/public/uploads/";

                mkdirp(dir, function(err) {
                    if (err) {
                        console.error(err);
                    }  else {
                        console.log("Directory created!");
                    }
                });

                console.log("Server runs on Port: " + process.env.PORT + " " + process.env.ROOT);
            });
        });

        this.app.get("/", function(req, res) {
            res.sendFile(process.env.NODE_PATH + "/index.html", { root : process.env.ROOT});
        });

        this.app.get("/js/*", function(req, res) {
            let jspth = req.url;
            let js = process.env.NODE_PATH + jspth;
            res.sendFile(js, { root : process.env.ROOT});
        });

        this.app.get("/assets/icons/*", function(req, res, path) {
            let iconpth = req.url;
            let icon = process.env.NODE_PATH + iconpth;
            res.sendFile(icon, { root : process.env.ROOT});
        });

        this.app.post("/share", async (req, res) => {
            if (req.body !== undefined || req.body !== null) {
                await req.context.models.Detection.create({
                    location: {
                        type: "Point",
                        coordinates: [req.body.longitude,
                            req.body.latitude]

                    },
                    spoofDecision: req.body.spoofDecision,
                    technologyid: req.body.technologyid,
                    technology: req.body.technology,
                    amplitude: req.body.amplitude,
                    timestamp: req.body.timestamp,
                    child: {
                        audiodata: req.body.audiodata,
                    }
                }).then((detection) => {
                    
                });
                res.json({status: 0, message: "Shared successfully"});
            } else {
                res.json({status: 1, message: "Sharing failed"});
            }
        });

        this.app.post("/audioshare", upload.single("audio"), async (req, res) => {
            if (req.file !== undefined || req.file !== null) {
                sftp.connect({
                    host: process.env.FILESERVER_HOSTNAME,
                    port: 22,
                    username: process.env.FILESERVER_USER,
                    password: process.env.FILESERVER_PASSWORD
                }).then(() => {
                    let uploadBuffer = Buffer.from(new Uint8Array(req.file.buffer));
                    sftp.put(uploadBuffer, process.env.FILESERVER_HOSTNAME + "/public/uploads/" +
                        req.file.originalname).then((data) => {
                            res.json({status: 0, message: "Shared successfully"});
                            sftp.end();
                        });
                }).catch((err) => {
                    res.json({status: 1, message: "Sharing failed"});
                    sftp.end();
                });
            } else {
                res.json({status: 1, message: "Sharing failed"});
            }
        });

        this.app.get("/getNumberOfImportDetections", async (req, res) => {
            this.detectionController.getFullFilteredDetections(req.query).then((detections) => {
                this.detectionController.groupDetections(detections).then((groupedDetections) => {
                    res.json(Object.keys(groupedDetections.detectionList).length);
                });
            });
        });

        this.app.get("/importDetections", async (req, res) => {
            this.detectionController.getFullFilteredDetections(req.query).then((detections) => {
                this.detectionController.groupDetections(detections).then((groupedDetections) => {
                    res.json(groupedDetections.detectionList);
                });
            });
        });

        this.app.get("/technologies", async (req, res) => {
            this.technologyController.getAllTechnologies().then((technologies) => {
                res.json(technologies);
            });
        });

        this.app.get("/wakeup", async (req, res) => {
            if (req.file !== undefined || req.file !== null) {
                res.json({status: 0, message: "Shared successfully"});
            } else {
                res.json({status: 1, message: "Sharing failed"});
            }
        });
    }

}
