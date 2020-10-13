import React from "react";
import classes from "./Stories.css";
import Story from "./Story/Story";

const stories = (props) => {
  return (
    <div className={["card", classes.StoryCard].join(" ")}>
      <div className={["card-body", classes.StoryCardBody].join(" ")}>
        {props.stories.map((story) => {
          return <Story author={story.author}></Story>;
        })}
      </div>
    </div>
  );
};

export default stories;