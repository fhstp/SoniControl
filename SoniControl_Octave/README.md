# SoniControl

SoniControl is a novel technology for the recognition and masking of acoustic tracking information. The technology helps end-users to protect their privacy. Technologies like Google Nearby and Silverpush build upon ultrasonic sounds to exchange information. More and more of our devices communicate via this inaudible communication channel. Every device with a microphone and a speaker is able to send and receive ultrasonic information. The user is usually not aware of this inaudible and hidden data transfer. To overcome this gap SoniControl detects ultrasonic activity, notifies the user and blocks the information on demand. Thereby, we want to raise the awareness for this novel technology.

## Code and Dependencies

This code contains scripts and prototypes developed in the SoniControl project (http://sonicontrol.fhstp.ac.at). 

External dependencies:
- This code is optimized to run under GNU Octave
- This code needs the LTFAT library (http://ltfat.sourceforge.net/), available also directly as a GNU Octave package for real-time audio processing. To install LTFAT under Octave run: "pkg install -forge ltfat". After installation make sure all files are in folder [OCTAVE_ROOT]\packages\ltfat-2.2.0. There should also be binaries in [[OCTAVE_ROOT]\packages]\packages\ltfat-2.2.0\x86_64-w64-mingw32-api-v51. Add both folder to the Octave path (with subfolders). To see if the installation has worked, run: "demo_blockproc_slidingsgram('playrec')". Note: no compilation is necessary. Mingw is automatically installed with Octave. Also a jdk is installed with octave. The portaudio library is not needed under windows.

Note: There are incompatibilities between 32-bit and 64-bit versions of GNU Octave, LTFAT, and Java. In case of problems, please try to use the 32-bit versions for all of these.

## Installation / First Start

After installing LTFAT, add the code folder plus all subfolders to the octave path and run realTimeDetectorConfig.m. The realtime detection should start immediately. 
You can test the real time detector with the ultrasonic recordings available on our website: http://sonicontrol.fhstp.ac.at/ (under "ressources")

## License

This project is licensed under the GNU General Public License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Project funded by [netidee](https://www.netidee.at/)
* SoniControl is a project of the Institute for Creative\Media/Technologies [(IC\M/T)](https://icmt.fhstp.ac.at), developed at the University of Applied Science Sankt Pölten [(FHSTP)](https://www.fhstp.ac.at/en)

## Contact: 

Contact us at: sonicontrol@fhstp.ac.at in case of questions


