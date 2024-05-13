# SCRLogic

<p align="center">
<img src="https://raw.githubusercontent.com/gary-1959/SCRLogic/main/images/SCR-Logic-Banner-2.png" alt="FutureNET DASH Logo" title="FutureNET DASH Logo">
</p>


SCRLogic is a software simulation package for training rig electricians to troubleshoot SCR systems.

It is written in C# for a Windows PC. There is some fairly trivial license protection built in, which can be fairly easily overridden in the source to fully unlock the entire package. As it is it will run in a limited demo mode. Permission is hereby granted by anyone to remove this protection and publish with the appropriate credits.

The file SCRLogic.zip contains a downloadable installer so might be worth a try if you don't fancy rebuilding the project. 
																
Although it is based on a Hill Graham Controls Land Rig, the control philosophy is almost identical to Ross Hill and similar systems, and the fault-finding techniques learned by using the software can be applied to a whole range of equipment.

The software is built of two parts: the graphic representation of the system equipment, and a mathematical simulation of the analogue circuits. 

The student can probe terminals on the simulation screens and measure the voltage at each point.

Faults can be applied to the circuit, which then allows the student to practice identification of faults by understanding the schematics and the observed measurements.

Faults can be introduced manually or from a pre-defined timed sequence of events controlled by a script running in the background. Scripts can be customised and saved and can create complex scenarios which will test the abilities of the most experienced technician.

The simulated system contains four SCRs, dual motor Drawworks, a Rotary Table and two parallel-motor Mud Pumps. Access is available to all four SCRs, the Drillers Console and Foot Throttle, blower MCC starters and the motor terminal boxes. 

Note that SCRLogic incorporates no generator control logic because the system complexity lies with the DC Motor and Auxiliary control circuits.

This program assumes that the user understands what an SCR system is, what it is used for and how it works, and is familiar with the terminology associated with a drilling rig. However it could be used as a training aid to introduce SCR systems to electricians from an industrial or domestic background.

To understand the full capabilities of SCRLogic a User Manual PDF is available here.

## Installation

The software has complex calculations to perform to simulate the analogue circuitry, so a Windows (version 7 or later) PC with plenty of memory (at least 4GB) and a powerful CPU will improve the user experience. The software will run on 32-bit machines, but these may experience memory problems due to memory fragmentation, so 64-bit is recommended.

A mouse with a scroll wheel is required.

The demo version has some limitations on usage (most notably scripting and a limited number of faults) and will time out after 20 minutes of use. To unlock all the features you would need to remove the trivial licensing protection in the source and and recompile.