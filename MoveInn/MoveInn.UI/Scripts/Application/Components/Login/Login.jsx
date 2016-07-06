var HelloWorld = React.createClass({
    render: function(){
        return (
            <div>Hello {this.props.name}</div>
            );
}
});

ReactDOM.render(<HelloWorld name="World" />, document.getElementById('container'));