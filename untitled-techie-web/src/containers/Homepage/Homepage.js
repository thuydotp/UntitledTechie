import React, { Component } from "react";
import Aux from "../../hoc/MyAux";
import Post from "../../components/Post/Post";
import Story from "../../components/Story/Story";

class Homepage extends Component {
  render() {
    return (
      <Aux>
        <div className="container">
          <div className="row">
            <div className="col-md-9">
              <div>
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
            <div className="col-md-9"></div>
          </div>
        </div>
      </Aux>
    );
  }
}

export default Homepage;
