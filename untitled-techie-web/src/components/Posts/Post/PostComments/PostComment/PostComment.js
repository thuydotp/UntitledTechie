import React from "react";
import Media from "react-bootstrap/Media";

const postComment = (props) => {
  let comment = props.comment;

  let result = null;
  if (comment) {
    let children = null;
    if (props.children) {
      children = props.children;
    }

    result = (
      <Media as="li">
        <img
          width={64}
          height={64}
          className="mr-3 rounded-circle"
          src="https://picsum.photos/64"
          alt="Generic placeholder"
        />
        <Media.Body>
          <h5>{comment.author}</h5>
          <p>{comment.description}</p>
          <div>{children}</div>
        </Media.Body>
      </Media>
    );
  }
  return result;
};

export default postComment;
