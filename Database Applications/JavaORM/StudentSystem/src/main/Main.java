package main;

import model.Course;
import model.Resource;
import model.Student;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;

public class Main {

    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("studentDb");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();

    /*    Student s = new Student();
        s.setFirstName("Ts");
        s.setLastName("Bombas");
        em.persist(s);


        Course c = new Course();
        c.setName("Java Coding");
        c.setDescription("Java basics coding");
        c.setStartDate(new Date());
        em.persist(c);
*/
        Resource r = new Resource();
        r.setName("test1");
        //r.setCoursec);
        r.setLink("abv.bg1");
      //  r.setCourseId(2);
        em.persist(r);
  //      c.getResources().add(r);

        CriteriaBuilder cb = em.getCriteriaBuilder();
        CriteriaQuery<Student> studentQuery =  cb.createQuery(Student.class);
        Root<Student> s = studentQuery.from(Student.class);
        s.join(Course.class);
        s.select(s);

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}
