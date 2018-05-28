package com.concurrent.main;

import com.concurrent.printer.imp.LaserPrinter;
import com.concurrent.printer.inf.Printer;
import com.concurrent.student.Student;
import com.concurrent.technician.PaperTechnician;
import com.concurrent.technician.Technician;
import com.concurrent.technician.TornerTechnican;

public class PrintingSystem {

    public static void main(String[] args) {


        LaserPrinter laserPrinter = new LaserPrinter(0,
                250,"LaserPrinter",250);

        ThreadGroup studentThreadGroup = new ThreadGroup("StudentThreadGroup");
        ThreadGroup technicianThreadGroup = new ThreadGroup("TechnicianThreadGroup");

        Technician tornerTechnician = new TornerTechnican("Torner Technician",technicianThreadGroup,laserPrinter);
        Technician paperTechnician = new PaperTechnician("Paper Technician", technicianThreadGroup, laserPrinter);

        String[] studentNames = new String[]{"Sachith","Ushan","Dasun", "Nimal"};
        Student[] students = new Student[4];
        tornerTechnician.start();
        paperTechnician.start();

        for (int i = 0; i < studentNames.length; i++){
           students[i] =  new Student(studentNames[i],studentThreadGroup,laserPrinter);
           students[i].start();
        }

        try {
            students[0].join();
            students[1].join();
            students[2].join();
            students[3].join();
            paperTechnician.join();
            tornerTechnician.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("-------------All thread successfully terminated -------------------------");
        System.out.println(" Finl  Printer status is :"+ laserPrinter.toString());
        System.out.println("-------------------------------------------------------------------------");

        laserPrinter.printReport();


    }
}
