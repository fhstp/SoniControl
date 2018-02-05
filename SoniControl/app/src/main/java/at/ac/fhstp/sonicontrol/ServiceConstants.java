package at.ac.fhstp.sonicontrol;


public class ServiceConstants {

    public interface ACTION {
        public static String MAIN_ACTION = "at.ac.fhstp.sonicontrol.action.main";
        public static String STARTFOREGROUND_ACTION = "at.ac.fhstp.sonicontrol.action.startforeground";
        public static String STOPFOREGROUND_ACTION = "at.ac.fhstp.sonicontrol.action.stopforeground";
    }

    public interface NOTIFICATION_ID {
        public static int FOREGROUND_SERVICE = 101;
    }
}
