import data.*;
import data.DAO.EmployeeDao;
import org.hibernate.Session;
import org.hibernate.SessionFactory;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        EntityManagerFactory employeesEntityFactory = Persistence.createEntityManagerFactory("Employeees");
        EntityManager employeesDb = employeesEntityFactory.createEntityManager();
        EmployeeDao employeeDao = new EmployeeDao(employeesDb);


        // Read
        System.out.println("******* READ *******");
        List<Employee> employees = employeeDao.list();
        System.out.println("Total Employees: " + employees.size());

        // Write
        System.out.println("******* WRITE *******");
        Employee empl = new Employee("Jack", "Bauer", new java.util.Date(System.currentTimeMillis()), "911");
        empl = employeeDao.save(empl);
        empl = employeeDao.read(empl.getId());
        System.out.printf("%d %s %s \n", empl.getId(), empl.getFirstName(), empl.getLastName());


        // Update
        System.out.println("******* UPDATE *******");
        Employee empl2 = employeeDao.read(1l); // read employee with id 1
        System.out.println("Name Before Update:" + empl2.getFirstName());
        empl2.setFirstName("James");
        employeeDao.update(empl2);  // save the updated employee details

        empl2 = employeeDao.read(1l); // read again employee with id 1
        System.out.println("Name Aftere Update:" + empl2.getFirstName());

        // Delete
        System.out.println("******* DELETE *******");
        //delete(empl);
        Employee empl3 = employeeDao.read(empl.getId());
        System.out.println("Object:" + empl3);
    }
}
