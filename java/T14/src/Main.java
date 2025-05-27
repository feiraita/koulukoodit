import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Give me a radius(cm): ");
        float radius = scan.nextFloat();

        double sphereA = 4 * Math.PI * Math.pow(radius, 2);
        double sphereV = 4 * Math.PI * Math.pow(radius, 3) / 3;

        System.out.printf("Area of the sphere: %.2f cm^2\nVolume of the sphere: %.2f cm^3", sphereA, sphereV);
    }
}