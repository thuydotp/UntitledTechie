import React, { Component } from "react";
import Aux from "../../hoc/MyAux";
import Post from "../../components/Post/Post";
import Story from "../../components/Story/Story";
import classes from "./Homepage.css";
class Homepage extends Component {
  author = {
    username: "nuocepanhdao",
    fullname: "Anita Do",
  };

  render() {
    return (
      <Aux>
        <div className="container">
          <div className="row">
            <div className="col-md-8">
              <div className={["card", classes.StoryCard].join(" ")}>
                <div className={["card-body", classes.StoryCardBody].join(" ")}>
                  <Story author="doc.sach.moi.ngay"></Story>
                  <Story author="interaction_design_foundation"></Story>
                  <Story author="moingay1trangsach"></Story>
                  <Story author="tinhte_official"></Story>
                  <Story author="nguoi.doc.sach"></Story>
                  <Story author="doc.sach.moi.ngay"></Story>
                  <Story author="interaction_design_foundation"></Story>
                  <Story author="moingay1trangsach"></Story>
                  <Story author="tinhte_official"></Story>
                  <Story author="nguoi.doc.sach"></Story>
                </div>
              </div>
              
              <Post
                author="thegoodquote"
                caption="Learn to let go #goodquote"
              ></Post>
              <Post
                author="thegoodquote"
                caption="Learn to let go #goodquote"
              ></Post>
              <Post
                author="thegoodquote"
                caption="Learn to let go #goodquote"
              ></Post>
              <Post
                author="thegoodquote"
                caption="Learn to let go #goodquote"
              ></Post>
            </div>
            <div className="col-md-4">
              <div className="media">
                <img
                  className="mr-3 rounded-circle"
                  src="https://picsum.photos/56"
                  alt="Generic placeholder image"
                />
                <div className="media-body">
                  <a className={["mt-0", classes.Username].join(" ")}>
                    {this.author.username}
                  </a>
                  <div className={classes.Fullname}>{this.author.fullname}</div>
                </div>
              </div>

              <div>
                <div className="d-flex justify-content-between">
                  <div>Suggestions for you</div>
                  <a href="#">See All</a>
                </div>
                <div className="d-flex justify-content-between">
                  <div className="media">
                    <img
                      className="mr-3 rounded-circle"
                      src="https://picsum.photos/32"
                      alt="Generic placeholder image"
                    />
                    <div className="media-body">
                      <a className={["mt-0", classes.Username].join(" ")}>
                        {this.author.username}
                      </a>
                      <div className={classes.Fullname}>
                        {this.author.fullname}
                      </div>
                    </div>
                  </div>
                  <a href="#">Follow</a>
                </div>
                <div className="d-flex justify-content-between">
                  <div className="media">
                    <img
                      className="mr-3 rounded-circle"
                      src="https://picsum.photos/32"
                      alt="Generic placeholder image"
                    />
                    <div className="media-body">
                      <a className={["mt-0", classes.Username].join(" ")}>
                        {this.author.username}
                      </a>
                      <div className={classes.Fullname}>
                        {this.author.fullname}
                      </div>
                    </div>
                  </div>
                  <a href="#">Follow</a>
                </div>
                <div className="d-flex justify-content-between">
                  <div className="media">
                    <img
                      className="mr-3 rounded-circle"
                      src="https://picsum.photos/32"
                      alt="Generic placeholder image"
                    />
                    <div className="media-body">
                      <a className={["mt-0", classes.Username].join(" ")}>
                        {this.author.username}
                      </a>
                      <div className={classes.Fullname}>
                        {this.author.fullname}
                      </div>
                    </div>
                  </div>
                  <a href="#">Follow</a>
                </div>
                <div className="d-flex justify-content-between">
                  <div className="media">
                    <img
                      className="mr-3 rounded-circle"
                      src="https://picsum.photos/32"
                      alt="Generic placeholder image"
                    />
                    <div className="media-body">
                      <a className={["mt-0", classes.Username].join(" ")}>
                        {this.author.username}
                      </a>
                      <div className={classes.Fullname}>
                        {this.author.fullname}
                      </div>
                    </div>
                  </div>
                  <a href="#">Follow</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Aux>
    );
  }
}

export default Homepage;
