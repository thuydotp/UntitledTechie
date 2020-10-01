import React from "react";
import Aux from "../../hoc/MyAux";
import classes from "./Post.css";

import Card from "react-bootstrap/Card";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const post = (props) => {
  return (
    <Aux>
      <Card className={classes.CardWrapper}>
        <Card.Header className={classes.CardHeader}>
          <div>{props.author}</div>
          <FontAwesomeIcon icon="ellipsis-h" size="sm" />
        </Card.Header>
        <Card.Img src="https://picsum.photos/600/600" />
        <Card.Body className={classes.CardBody}>
          <div className={classes.PostControlBar}>
            <div>
              <FontAwesomeIcon icon="heart" size="sm" className={classes.PostControlBarIcon}/>
              <FontAwesomeIcon icon="comment" size="sm" className={classes.PostControlBarIcon}/>
              <FontAwesomeIcon icon="share-square" size="sm" className={classes.PostControlBarIcon}/>
            </div>
            <div>
              <FontAwesomeIcon icon="bookmark" size="sm" className={classes.PostControlBarIcon}/>
            </div>
          </div>
          <Card.Text><b>{props.author}</b> {props.caption}</Card.Text>
        </Card.Body>
      </Card>
    </Aux>
  );
};

export default post;
