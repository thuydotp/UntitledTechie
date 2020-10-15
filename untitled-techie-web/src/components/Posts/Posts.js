import React from "react";
import Post from "./Post/Post";

const posts = (props) => {
  return props.posts.map((post) => {
    return (
      <Post key={post.id} post={post}></Post>
    );
  });
};

export default posts;
