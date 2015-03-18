package model.DAO;

import model.Course;

import javax.persistence.EntityManager;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.JoinType;
import javax.persistence.criteria.Root;
import java.util.List;

public class CourseDao extends BaseDao {

    public CourseDao(EntityManager em)
    {
        super(em);
    }

    public List<Course> allCoursesWithResources(){
        CriteriaQuery<Course> courseCriteriaQuery =  this.criteriaBuilder.createQuery(Course.class);
        Root<Course> courseRoot = courseCriteriaQuery.from(Course.class);
        courseRoot.fetch("resources", JoinType.LEFT);

        TypedQuery<Course> results = this.entityManager.createQuery(courseCriteriaQuery);
        return  results.getResultList();
    }
}
