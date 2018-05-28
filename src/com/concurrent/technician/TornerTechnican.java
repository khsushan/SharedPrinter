package com.concurrent.technician;

import com.concurrent.printer.inf.ServicePrinter;

import java.util.Random;

public class TornerTechnican extends  Technician {

    public  TornerTechnican(String technicianName, ThreadGroup threadGroup, ServicePrinter laserPrinter){
        super(technicianName,threadGroup,laserPrinter);

    }

    @Override
    public void run() {
        Random numGen = new Random();
        int noOfRefills = 3;

        while(noOfRefills > 0){
            System.out.println("Thread[ " + this.utilityThread.getName() + " ] refilling the printer ");
            this.laserPrinter.replaceTonerCartridge();
            System.out.println("Printer state is : " + laserPrinter.toString());
            try{
                int time = numGen.nextInt(4000)+1000;
                System.out.println("Thread[ " + this.utilityThread.getName() + " ] waiting for " + time/1000 + " seconds");
                Thread.sleep(time);
            }
            catch (InterruptedException e){
                e.printStackTrace();
            }
            noOfRefills--;

        }
        System.out.println("Terminating thread "+ this.utilityThread.getName());
    }
}
