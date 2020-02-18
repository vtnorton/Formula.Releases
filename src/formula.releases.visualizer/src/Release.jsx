import React, { useState } from "react";
import ReactMarkdown from "react-markdown";

const VerifyText = text => {
	if (!text.startsWith("<")) return text;
	else return "Something went wrong";
};

const Release = props => {
	const [markdownText, setMarkdownText] = useState("loading...");

	fetch("/release/" + props.match.params.filename + ".md")
		.then(response => response.text())
		.then(text => setMarkdownText(text));

	return props.match.params.filename ? (
		<ReactMarkdown source={VerifyText(markdownText)} />
	) : (
			<div>no file</div>
		);
};

export default Release;
