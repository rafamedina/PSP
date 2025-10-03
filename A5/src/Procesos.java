import java.time.LocalTime;

public class Procesos {
    public static void main(String[] args) throws InterruptedException {
        Thread t1 = new Thread(new Programa("numero1.txt"));
        Thread t2 = new Thread(new Programa("numero2.txt"));
        Thread t3 = new Thread(new Programa("numero3.txt"));
        try{
            System.out.println("Proceso 1 empieza en: " + LocalTime.now());
            t1.start();
            System.out.println("Proceso 2 empieza en: " + LocalTime.now());
            t2.start();
            System.out.println("Proceso 3 empieza en: " + LocalTime.now());
            t3.start();
            t1.join();t2.join();t3.join();
        } catch (RuntimeException e) {
            throw new RuntimeException(e);
        }
    }
}
