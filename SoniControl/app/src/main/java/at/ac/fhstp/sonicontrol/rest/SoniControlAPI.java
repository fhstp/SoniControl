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
