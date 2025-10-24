public class Carrera {
    public static void main(String[] args) {
        // Creamos tres corredores
        Corredor c1 = new Corredor("Corredor 1");
        Corredor c2 = new Corredor("Corredor 2");
        Corredor c3 = new Corredor("Corredor 3");

        // Iniciamos los hilos (la carrera empieza)
        c1.start();
        c2.start();
        c3.start();

        // Esperamos a que todos terminen antes de determinar el ganador
        try {
            c1.join();
            c2.join();
            c3.join();
        } catch (InterruptedException e) {
            System.out.println("La carrera fue interrumpida.");
        }

        System.out.println("🏁 ¡La carrera ha terminado! Todos los corredores han llegado a la meta.");
    }
}