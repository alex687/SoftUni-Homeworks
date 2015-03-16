package model;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "homeworks")
public class Homework {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable =  false)
    private byte[] content;

    @Column(nullable = false)
    private String contentType;

    private Date sentOn;

    @ManyToOne
    private Student student;

    @ManyToOne
    private Course course;
}
