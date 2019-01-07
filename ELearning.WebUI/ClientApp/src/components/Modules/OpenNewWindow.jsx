import React, { Component } from 'react';
import NewWindow from 'react-new-window';

class OpenNewWindow extends Component {

    componentDidMount = () => {
        //const code = this.props.htmlCode;
        console.log(this.props);
    }

    render() {
        const html = <p>Jestem html</p>;
        const string = '<p>Jestem string</p>';
        //const code = this.props.htmlCode;
        return (
            <NewWindow>
                <button onClick={this.props.close}>Zamknij</button>

                <html>
                    <head>
                        <title>Przykład</title>
                    </head>
                    <body>
                        <p>Witaj Świecie!</p>
                    </body>
                </html>
                {/* {html}
                {string}
                {this.props.htmlCode} */}
            </NewWindow>
        )
    }
}
export default OpenNewWindow;