import java.util.concurrent.locks.ReentrantLock;

public class Garfo {
    private final ReentrantLock lock = new ReentrantLock(true);
    private final int id;

    public Garfo(int id) {
        this.id = id;
    }

    public void pegar() {
        lock.lock();
        System.out.println("Garfo " + id + " foi pego.");
    }

    public void soltar() {
        System.out.println("Garfo " + id + " foi solto.");
        lock.unlock();
    }

    public int getId() {
        return id;
    }
}
