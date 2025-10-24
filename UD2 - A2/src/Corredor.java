class Corredor extends Thread {
    private String nombre;

    // Constructor para asignar nombre al corredor
    public Corredor(String nombre) {
        this.nombre = nombre;
    }

    // Método que define el comportamiento del hilo
    @Override
    public void run() {
        System.out.println(nombre + " ha comenzado la carrera.");

        // Simulamos el progreso del corredor con una pausa aleatoria
        for (int i = 1; i <= 5; i++) {
            System.out.println(nombre + " ha avanzado hasta el punto " + i + ".");
            try {
                // Simula el tiempo que tarda en avanzar (entre 500 y 1000 ms)
                Thread.sleep((int)(Math.random() * 500 + 500));
            } catch (InterruptedException e) {
                System.out.println(nombre + " fue interrumpido.");
            }
        }

        System.out.println(nombre + " ha terminado la carrera.");
    }
}