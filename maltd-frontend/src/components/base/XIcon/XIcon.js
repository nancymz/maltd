import React from "react";
import PropTypes from "prop-types";
import Icon from "../../../img/x-icon.PNG";
import "./XIcon.css";

export default function XIcon({ onClick, id }) {
  return (
    <div
      role="button"
      tabIndex="0"
      onClick={() => onClick(id)}
      onKeyDown={() => onClick(id)}
      className="icon"
      data-cy="close-icon"
    >
      <img src={Icon} alt="x icon" width="25px" height="25px" />
    </div>
  );
}

XIcon.propTypes = {
  onClick: PropTypes.func.isRequired,
  id: PropTypes.string.isRequired
};
