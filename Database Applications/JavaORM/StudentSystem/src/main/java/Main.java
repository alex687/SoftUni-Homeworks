import model.DAO.*;
import model.*;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) {
        EntityManagerFactory studentDbEntityManagerFactory =
                Persistence.createEntityManagerFactory("studentDb");
        EntityManager studentEm = studentDbEntityManagerFactory.createEntityManager();

        try {
            studentEm.getTransaction().begin();
    /*    Student s = new Student();
        s.setFirstName("Ts");
        s.setLastName("Bombas");
        em.persist(s);


        Course c = new Course();
        c.setName("Java Coding");
        c.setDescription("Java basics coding");
        c.setStartDate(new Date());
        em.persist(c);

        Resource r = new Resource();
        r.setName("test1");
        //r.setCoursec);
        r.setLink("abv.bg1");
      //  r.setCourseId(2);
        em.persist(r);
  //      c.getResources().add(r);
*/
            StudentDao studentDao = new StudentDao(studentEm);
            for (Student student : studentDao.allStudentsWithCoursesAndHomeworks()) {
                System.out.println(student.getFirstName() + " " + student.getLastName());

                List<Course> courses = new ArrayList<>(student.getCourses());
                List<String> coursesNames = courses.stream().map(Course::getName).collect(Collectors.toList());

                System.out.println("       " + coursesNames);
            }

            CourseDao courseDao = new CourseDao(studentEm);
            for (Course course : courseDao.allCoursesWithResources()) {
                System.out.println(course.getName() + " " + course.getDescription());

                List<Resource> resources = new ArrayList<>(course.getResources());
                List<String> resourcesNames = resources.stream().map(Resource::getName).collect(Collectors.toList());

                System.out.println("       " + resourcesNames);
            }


        } catch (Exception e) {
            throw e;
        } finally {
            studentEm.getTransaction().commit();
            studentEm.close();
            studentDbEntityManagerFactory.close();
        }
    }
}
