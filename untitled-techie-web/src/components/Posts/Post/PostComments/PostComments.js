import React from "react";
import PostComment from "./PostComment/PostComment";
import Media from "react-bootstrap/Media";

const postComments = (props) => {
  let comments = null;
  let subComments = null;

  if (props.comments) {
    comments = props.comments.map((cmt) => {
      if (cmt.subComments) {
        subComments = cmt.subComments.map((subCmt) => {
          return <PostComment key={subCmt.id} comment={subCmt}></PostComment>;
        });

        subComments = <ul className="list-unstyled">{subComments}</ul>;
      }

      return (
        <div as="li" key={cmt.id}>
          <PostComment comment={cmt}>{subComments}</PostComment>
        </div>
      );
    });
  }

  return <ul className="list-unstyled">{comments}</ul>;
};

export default postComments;
