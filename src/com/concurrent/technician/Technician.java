package com.concurrent.technician;

import com.concurrent.printer.inf.ServicePrinter;

public abstract class Technician  extends  Thread{

    protected Thread utilityThread;
    protected ThreadGroup threadGroup;
    protected ServicePrinter laserPrinter;
    protected   String technicianName;

    public  Technician(String technicianName, ThreadGroup threadGroup, ServicePrinter laserPrinter){
        super(threadGroup,technicianName);
        this.technicianName = technicianName;
        this.threadGroup = threadGroup;
        this.laserPrinter = laserPrinter;
        this.utilityThread =  new Thread(threadGroup, technicianName);
    }

    public void start() {
        super.start();
        System.out.println("Starting " + utilityThread.getName() + " thread.");
    }
}
