package at.ac.fhstp.sonicontrol.rest;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import at.ac.fhstp.sonicontrol.BuildConfig;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RESTController {

    private static Retrofit retrofit;


    private static final String BASE_URL = BuildConfig.BASE_URL;

    public static Retrofit getRetrofitInstance() {
        if (retrofit == null) {
            Gson gson = new GsonBuilder()
                    .setLenient()
                    .create();



            retrofit = new retrofit2.Retrofit.Builder()
                    .baseUrl(BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create(gson))
                    .build();
        }
        return retrofit;
    }

}
