package com.concurrent.student;
import com.concurrent.document.Document;
import com.concurrent.printer.inf.Printer;

import java.util.Random;

public class Student extends   Thread{

    private Thread utilityThread;
    private ThreadGroup threadGroup;
    private Printer laserPrinter;
    private String studentName;


    public  Student(String studentName, ThreadGroup threadGroup, Printer laserPrinter){
        super(threadGroup, studentName);
        this.studentName = studentName;
        this.threadGroup = threadGroup;
        this.laserPrinter = laserPrinter;
        this.utilityThread =  new Thread(threadGroup, studentName);
    }

    public void start() {
        System.out.println("Starting " + utilityThread.getName() + " thread.");
        super.start();
    }


    @Override
    public void run() {
        int numOfPrint = 5;
        Random numGen = new Random();

        while (numOfPrint > 0){
            System.out.println("Thread[ " + this.utilityThread.getName() + " ] printing the document ");
            Document document = new Document(this.studentName,"CW"+numOfPrint, numGen.nextInt(20));
            this.laserPrinter.printDocument(document);
            System.out.println("Thread[ " + this.utilityThread.getName() + " ] printed  the document printer state is : "
                    + laserPrinter.toString());
            try{
                int time = numGen.nextInt(4000)+1000;
                System.out.println("Thread[ " + this.utilityThread.getName() + " ] waiting for " + time/1000 + " seconds");
                Thread.sleep(time);
            }
            catch (InterruptedException e){
                e.printStackTrace();
            }
            numOfPrint--;
        }
    }
}
