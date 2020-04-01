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
import {DataFactory} from "./dataFactory";
require("dotenv").config();

export class Connection {
    public static getInstance(): Connection {
        if (Connection.instance === null || Connection.instance === undefined) {
            Connection.instance = new Connection();
        }
        return Connection.instance;
    }

    private static instance: Connection;
    private database: any;

    private constructor() {
    }

    private connectDb = () => {
        return mongoose.connect(process.env.DATABASE_URL, {useNewUrlParser: true}, function(err) {
            if (err) { throw err; }
            const dataFactory = DataFactory.getInstance();
            dataFactory.createData();
        });
    }
}
