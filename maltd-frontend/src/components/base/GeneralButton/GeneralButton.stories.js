import React from "react";
import { action } from "@storybook/addon-actions";
import { storiesOf } from "@storybook/react";
import "bootstrap/dist/css/bootstrap.css";
import GeneralButton from "./GeneralButton";

const generalButton = {
  type: "submit",
  color: "primary",
  disabled: true,
  label: "Find"
};

storiesOf("GeneralButton", module)
  .add("default", () => <GeneralButton generalButton={generalButton} />)
  .add("valid", () => (
    <GeneralButton
      generalButton={{ ...generalButton, disabled: false }}
      onClick={action("button clicked")}
    />
  ))
  .add("invalid", () => (
    <GeneralButton generalButton={{ ...generalButton, color: "danger" }} />
  ));
