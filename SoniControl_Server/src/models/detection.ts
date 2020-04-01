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

import mongoose = require("mongoose");
import { Schema } from "mongoose";

const audioSchema: Schema = new mongoose.Schema({
  audiodata: {
    type: String,
    unique: false,
  }
});

const detectionSchema: Schema = new mongoose.Schema({
  location: {
    type: {type: String},
    coordinates: {type: [Number]}
  },
  spoofDecision: {
    type: Number,
    unique: false,
  },
  technologyid: {
    type: Number,
    unique: false,
  },
  technology: {
    type: String,
    unique: false,
  },
  amplitude: {
    type: Number,
    unique: false,
  },
  timestamp: {
    type: Date,
    unique: false,
  },
  child: audioSchema
});

detectionSchema.index({ location: "2dsphere" });

const Detection = mongoose.model("Detection", detectionSchema);

export default Detection;
