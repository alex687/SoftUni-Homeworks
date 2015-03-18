package model;

import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.Min;
import java.util.Date;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "courses")
public class Course {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable = false)
    @Length(min = 2)
    private String name;

    @Column(columnDefinition = "TEXT")
    private String description;

    @Column(nullable = false)
    private Date startDate;

    private Date endDate;

    private double price;

    @ManyToMany(fetch = FetchType.LAZY, mappedBy = "courses")
    private Set<Student> students;

    @OneToMany(mappedBy = "course", fetch = FetchType.LAZY)
    private Set<Homework> homeworks;

    @OneToMany(mappedBy = "course", fetch = FetchType.LAZY)
    private Set<Resource> resources;

    public Course() {
        this.resources = new HashSet<Resource>();
        this.homeworks = new HashSet<Homework>();
        this.students = new HashSet<Student>();
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Date getStartDate() {
        return startDate;
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    public Date getEndDate() {
        return endDate;
    }

    public void setEndDate(Date endDate) {
        this.endDate = endDate;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public Set<Student> getStudents() {
        return students;
    }

    public Set<Homework> getHomeworks() {
        return homeworks;
    }

    public Set<Resource> getResources() {
        return resources;
    }
}
