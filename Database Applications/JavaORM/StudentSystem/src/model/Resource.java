package model;

import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.Min;
import java.util.Date;
import java.util.Locale;
import java.util.Set;

@Entity
@Table(name = "resources")
public class Resource {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable = false)
    @Length(min = 2)
    private String name;

    @Enumerated(EnumType.ORDINAL)
    private ResourceType resourceType;

    @Column(nullable = false)
    @Length(min=5)
    private String link;

    @ManyToOne(fetch = FetchType.LAZY)
    private Course course;

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ResourceType getResourceType() {
        return resourceType;
    }

    public void setResourceType(ResourceType resourceType) {
        this.resourceType = resourceType;
    }

    public String getLink() {
        return link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public Course getCourse() {
        return course;
    }

    public void setCourse(Course course) {
        this.course = course;
    }
}
