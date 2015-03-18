package model.DAO;

import javax.persistence.EntityManager;
import javax.persistence.criteria.CriteriaBuilder;

public class BaseDao {
    protected EntityManager entityManager;
    protected CriteriaBuilder criteriaBuilder;

    protected BaseDao(EntityManager em){
        this.entityManager = em;
        this.criteriaBuilder = em.getCriteriaBuilder();
    }

}
