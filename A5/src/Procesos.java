import java.time.LocalTime;

public class Procesos {
    public static void main(String[] args) throws InterruptedException {
        Thread t1 = new Thread(new Programa("numero1.txt"));
        Thread t2 = new Thread(new Programa("numero2.txt"));
        Thread t3 = new Thread(new Programa("numero3.txt"));

        System.out.println("Proceso 1 empieza en: " + LocalTime.now());
        t1.start();
        t1.join();

        System.out.println("Proceso 2 empieza en: " + LocalTime.now());
        t2.start();
        t2.join();

        System.out.println("Proceso 3 empieza en: " + LocalTime.now());
        t3.start();
        t3.join();
    }
}
