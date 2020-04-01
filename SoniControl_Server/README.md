# SoniControl

SoniControl is a novel technology for the recognition and masking of acoustic tracking information. The technology helps end-users to protect their privacy. Technologies like Google Nearby and Silverpush build upon ultrasonic sounds to exchange information. More and more of our devices communicate via this inaudible communication channel. Every device with a microphone and a speaker is able to send and receive ultrasonic information. The user is usually not aware of this inaudible and hidden data transfer. To overcome this gap SoniControl detects ultrasonic activity, notifies the user and blocks the information on demand. Thereby, we want to raise the awareness for this novel technology.

## Code and Dependencies

This code contains the Node.js server application for the SoniControl project (http://sonicontrol.fhstp.ac.at). 

External dependencies:
- The server application needs a MongoDB database to run.
- It uses Express.js and Socket.IO.

## Installation / First Start

To start the server, either a self-hosted solution is needed, or a free hosting platform like Heroku.
For hosting it on Heroku, a free account has to be created. There the Node.js application can be deployed via their Heroku CLI (more detailed [here](https://devcenter.heroku.com/articles/deploying-nodejs)).
Further, a MongoDB needs to be hosted somewhere. An example would be the free hosting plan at [MongoDB Atlas](https://www.mongodb.com/cloud/atlas).
Next, on the Heroku dashboard of the created and deployed application, several config vars need to be entered. Those are also in the repository as dotenv-file. An example is given in the repository. The path to the webfiles needs to be entered, as well as the port, rootpath and the database URL from MongoDB. All those entries are also needed for letting it run on a local machine. Therefore, the dotenv file needs to be copied, filled out and saved as '.env'.
Last, the fileupload needs a kind of webspace or space on a server. It is done via sftp and the hostname, password and the user have to be written in the .env-file/Heroku config vars.
Now the server can be started!

## License

This project is licensed under the GNU General Public License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Project funded by [netidee](https://www.netidee.at/)
* SoniControl is a project of the Institute for Creative\Media/Technologies [(IC\M/T)](https://icmt.fhstp.ac.at), developed at the University of Applied Science Sankt Pölten [(FHSTP)](https://www.fhstp.ac.at/en)

## Contact: 

Contact us at: sonicontrol@fhstp.ac.at in case of questions