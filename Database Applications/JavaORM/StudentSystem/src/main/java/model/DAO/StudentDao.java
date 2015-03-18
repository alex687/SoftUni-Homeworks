package model.DAO;

import model.Student;

import javax.persistence.EntityManager;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.JoinType;
import javax.persistence.criteria.Root;
import java.util.List;

public class StudentDao extends BaseDao {
    public StudentDao(EntityManager em)
    {
        super(em);
    }

    public List<Student> allStudentsWithCoursesAndHomeworks(){
        CriteriaQuery<Student> studentQuery =  this.criteriaBuilder.createQuery(Student.class);
        Root<Student> studentRoot = studentQuery.from(Student.class);
        studentRoot.fetch("courses", JoinType.LEFT);
        studentRoot.fetch("homeworks", JoinType.LEFT);

        TypedQuery<Student> results = this.entityManager.createQuery(studentQuery);
        return  results.getResultList();
    }
}
