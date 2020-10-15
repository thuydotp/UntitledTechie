import React from "react";
import Aux from "../../../hoc/MyAux";
import classes from "./Post.css";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Card from "react-bootstrap/Card";
import PostComments from "./PostComments/PostComments";

const post = (props) => {
  let post = props.post;
  return (
    <Aux>
      <Card className={classes.CardWrapper}>
        <Card.Header className={classes.CardHeader}>
          <div>{post.author}</div>
          <FontAwesomeIcon icon="ellipsis-h" size="lg" />
        </Card.Header>
        <Card.Img src="https://picsum.photos/600" />
        <Card.Body className={classes.CardBody}>
          <div className={classes.PostControlBar}>
            <div>
              <FontAwesomeIcon
                icon="heart"
                size="lg"
                className={classes.PostControlBarIcon}
              />
              <FontAwesomeIcon
                icon="comment"
                size="lg"
                className={classes.PostControlBarIcon}
              />
              <FontAwesomeIcon
                icon="share-square"
                size="lg"
                className={classes.PostControlBarIcon}
              />
            </div>
            <div>
              <FontAwesomeIcon
                icon="bookmark"
                size="lg"
                className={classes.PostControlBarIcon}
              />
            </div>
          </div>
          <Card.Text>
            <b>{post.author}</b> {post.caption}
          </Card.Text>
          <PostComments comments={post.comments}></PostComments>
        </Card.Body>
      </Card>
    </Aux>
  );
};

export default post;
