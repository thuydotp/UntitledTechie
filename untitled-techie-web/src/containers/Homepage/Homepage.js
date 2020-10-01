import React, { Component } from "react";
import Aux from "../../hoc/MyAux";
import Post from "../../components/Post/Post";

import Container from "react-bootstrap/Container";

class Homepage extends Component {
  render() {
    return (
      <Aux>
        <Container>
          <div>Stories</div>
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
        </Container>
      </Aux>
    );
  }
}

export default Homepage;
