import React from "react";

import Aux from "../../../hoc/MyAux";
import classes from "./Story.css";
import Image from "react-bootstrap/Image";

const story = (props) => {
  return (
    <Aux>
      <div className={classes.StoryWrapper}>
        <Image src="https://picsum.photos/56" roundedCircle />
        <div className={classes.StoryAuthor}>{props.author}</div>
      </div>
    </Aux>
  );
};

export default story;
