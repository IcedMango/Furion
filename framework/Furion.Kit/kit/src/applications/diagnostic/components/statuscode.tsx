import { Space, Tooltip } from "antd";
import React from "react";
import { styled } from "styled-components";
import IconFont from "../../../components/iconfont";
import TextBox from "../../../components/textbox";

const Container = styled.div`
  display: inline-block;
  font-size: 14px;
  font-weight: 600;
  letter-spacing: 0.5px;
`;

const Icon = styled(IconFont)`
  font-size: 15px;
`;

export const getIconColor = (code: number): [JSX.Element, string] => {
  if (code >= 200 && code <= 299) {
    return [<Icon type="icon-success" />, "#52c41a"];
  } else if (code >= 400 && code <= 499) {
    return [<Icon type="icon-warning" />, "#faad14"];
  } else if (code >= 500 && code <= 599) {
    return [<Icon type="icon-error" />, "#ff4d4f"];
  } else {
    return [<Icon type="icon-information" />, "#1677ff"];
  }
};

interface StatusCodeProps {
  code: number;
  text?: string;
  message?: string;
}

const StatusCode: React.FC<StatusCodeProps> = ({
  code,
  text = "",
  message,
}) => {
  const [icon, color] = getIconColor(code);
  const IconColor = React.cloneElement<any>(icon, { style: { color } });

  return (
    <Container>
      <Tooltip title={message} color="#ff4d4f">
        <Space align="center" size={5}>
          {IconColor}
          <TextBox $color={color}>
            {code} {text}
          </TextBox>
        </Space>
      </Tooltip>
    </Container>
  );
};

export default StatusCode;