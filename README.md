# OBD2Utility
Holds all code for our project which includes the code for the C# Application, Arduino Simulator and the Particle electron. The default branch is configured to "DemoDay" which contains all code shown on Demo Day. 

Located in ArduinoSimulatorCode is what ran on the simulator. This includes code for both sending and receiving CAN messages using the MCP2515 module. These files were used from the CAN Bus Shield library and modified to fit the needs for our simulator.

Located in OBD2_Utility is the C# Desktop Application. This is the main application that we showed on Demo Day which contains the graphing, dashboard, and necessary code to read from the Google Database.

Located in ParticleFirmWareCode is the firmware that ran on the Electron to communicate with the OBD2 port. This code contains the main functions to both request and receive data from the vehicle. Also included is the code to publish the data in the correct format to the database.

OBD2 Team - Danny Campbell, Josh Vidmar, Kale Thompson
