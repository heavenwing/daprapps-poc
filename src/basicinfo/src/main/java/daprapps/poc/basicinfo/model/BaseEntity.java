package daprapps.poc.basicinfo.model;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import java.io.Serializable;
import java.time.Instant;

@MappedSuperclass
public class BaseEntity implements Serializable {
    @Column(name = "create_by", nullable = false, length = 50)
    @JsonIgnore
    private String createBy;

    @Column(name = "create_time")
    @JsonIgnore
    private Instant createTime;

    @Column(name = "update_by", nullable = false, length = 50)
    @JsonIgnore
    private String updateBy;

    @Column(name = "update_time", updatable = false, insertable = false, nullable = false)
    @JsonIgnore
    private Instant updateTime;

    public Instant getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(Instant updateTime) {
        this.updateTime = updateTime;
    }

    public String getUpdateBy() {
        return updateBy;
    }

    public void setUpdateBy(String updateBy) {
        this.updateBy = updateBy;
    }

    public Instant getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Instant createTime) {
        this.createTime = createTime;
    }

    public String getCreateBy() {
        return createBy;
    }

    public void setCreateBy(String createBy) {
        this.createBy = createBy;
    }
}
