/*
 * Copyright (c) 2018, 2019. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
 *
 * This file is part of SoniControl app.
 *
 *     SoniControl app is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     SoniControl app is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with SoniControl app.  If not, see <http://www.gnu.org/licenses/>.
 */

package at.ac.fhstp.sonicontrol.rest;

import org.json.JSONObject;

import okhttp3.MultipartBody;
import okhttp3.RequestBody;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.Multipart;
import retrofit2.http.POST;
import retrofit2.http.Part;
import retrofit2.http.Query;

public interface SoniControlAPI {

    @POST("/share")
    @FormUrlEncoded
    Call<Detection> shareDetetion(@Field("longitude") double longitude,
                             @Field("latitude") double latitude,
                             @Field("spoofDecision") int spoofDecision,
                             @Field("technologyid") int technologyid,
                             @Field("technology") String technology,
                             @Field("amplitude") int amplitude,
                             @Field("timestamp") String timestamp,
                             @Field("audiodata") String audiodata);

    @POST("/audioshare")
    @Multipart
    Call<ResponseBody> uploadAudioFile(@Part MultipartBody.Part file,
                                       @Part("file") RequestBody name);

    @GET("/importDetections")
    Call<ResponseBody>  importDetections(@Query("longitude") double longitude,
                                       @Query("latitude") double latitude,
                                       @Query("technologyid") int technologyid,
                                       @Query("timestampfrom") String timestampfrom,
                                       @Query("timestampto") String timestampto);
}
