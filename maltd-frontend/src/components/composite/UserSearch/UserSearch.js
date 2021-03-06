import React from "react";
import PropTypes from "prop-types";
import InputField from "../../base/InputField/InputField";
import GeneralButton from "../../base/GeneralButton/GeneralButton";
import "./UserSearch.css";

export default function UserSearch({
  userSearch: { state },
  inputField,
  generalButton,
  onClick,
  onChange,
  onKeyEnter
}) {
  return (
    <div className="move-down">
      <p>
        Find a user by IDIR username and add them to or remove them from
        projects.
      </p>
      <p />
      {!state.isLoading && state.userExists === null && (
        <div className="inner">
          <InputField
            inputField={inputField}
            onChange={onChange}
            onKeyEnter={onKeyEnter}
          />
          <p />
          <div className="error-btn-div">
            <div />
            <div className="d-flex justify-content-end">
              <GeneralButton generalButton={generalButton} onClick={onClick} />
            </div>
          </div>
        </div>
      )}
      {state.isLoading && state.userExists === null && (
        <div className="inner">
          <div>
            <InputField inputField={inputField} />
            <p />
            <div>
              <div className="float-left">
                <p className="float-left">
                  <small id="loading">Loading...</small>
                </p>
              </div>
              <div className="d-flex justify-content-end">
                <GeneralButton generalButton={generalButton} />
              </div>
            </div>
          </div>
        </div>
      )}
      {state.userExists === false && (
        <div className="inner">
          <div>
            <InputField inputField={inputField} onChange={onChange} />
            <p />
            <div className="error-btn-div">
              <div className="float-left">
                <small className="error-message" data-cy="error-text">
                  This user does not exist, please try again with a different
                  IDIR username.
                </small>
              </div>
              <div className="d-flex justify-content-end">
                <GeneralButton generalButton={generalButton} />
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

UserSearch.propTypes = {
  userSearch: PropTypes.shape({
    state: PropTypes.any.isRequired
  }).isRequired,
  inputField: PropTypes.shape({
    type: PropTypes.string.isRequired,
    placeholder: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    valid: PropTypes.bool.isRequired,
    invalid: PropTypes.bool.isRequired,
    value: PropTypes.string.isRequired
  }).isRequired,
  generalButton: PropTypes.shape({
    type: PropTypes.string.isRequired,
    color: PropTypes.string.isRequired,
    disabled: PropTypes.bool.isRequired,
    label: PropTypes.any.isRequired
  }).isRequired,
  onClick: PropTypes.func,
  onChange: PropTypes.func,
  onKeyEnter: PropTypes.func
};

UserSearch.defaultProps = {
  onClick: () => {},
  onChange: () => {},
  onKeyEnter: () => {}
};
