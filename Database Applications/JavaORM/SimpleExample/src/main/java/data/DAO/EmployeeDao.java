package data.DAO;

import data.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import java.util.List;

public class EmployeeDao {

    private EntityManager entityManager;

    public EmployeeDao(EntityManager em) {
        this.entityManager = em;
    }

    public Employee save(Employee employee) {

        EntityTransaction transaction = this.entityManager.getTransaction();
        transaction.begin();
        entityManager.persist(employee);
        transaction.commit();

        return employee;
    }

    public List<Employee> list() {
        List<Employee> employees = this.entityManager.createQuery("select e from Employee e").getResultList();

        return employees;
    }

    public Employee read(Long id) {
        Employee employee = this.entityManager.find(Employee.class, id);

        return employee;
    }

    public Employee update(Employee employee) {
        this.entityManager.merge(employee);

        return employee;
    }

    public void delete(Employee employee) {
        this.entityManager.remove(employee);
    }
}
