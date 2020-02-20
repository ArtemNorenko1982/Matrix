import React, { Component } from 'react';
import { CSVLink } from "react-csv";
import CSVReader from "react-csv-reader";
import './MatrixGrid.css'
export class MatrixGrid extends Component {

    const = {
        defaultMatrixRowCount: Number,
        defaultMatrixColCount: Number
    };

    parseOptions = {
        dynamicTyping: true,
        skipEmptyLines: true
    }

    constructor(props) {
        super(props);
        this.state = {
            testMatrix: [[]],
            loading: true,
            row: 2,
            col: 2
        }

        this.defaultMatrixRowCount = 2;
        this.defaultMatrixColCount = 2;
    }

    render() {
        return (
            <div>
                <form id="matrixItem">
                    <div className="matrixItemContent">
                        {this.state.testMatrix.map((row, item) =>
                            (<div id={item} key={item}>
                                {row.map((col, element) => <span key={element}> | {col} | </span>)}
                            </div>))
                        }
                    </div>
                </form>
                <br></br>
                <div>
                    <button className="btn btn-primary" onClick={this.generate}>Generate matrix</button>
                    <a href="#" className="btn">
                        <input id="r" type="Number" defaultValue={this.state.row} value={this.state.col} max={10} min={2} onChange={this.handleRowColCount}></input> x <input id="c" type="Number" defaultValue={this.state.col} value={this.state.col} max={10} min={2} onChange={this.handleRowColCount}></input>
                    </a>
                    <button className="btn btn-primary" onClick={this.rotateClockWise}>Rotate clock wise</button>
                    <button className="btn btn-primary" onClick={this.rotateAntiClockWise}>Rotate anti clockwise</button>
                    <CSVLink className="btn btn-primary" filename={"matrix.csv"} data={this.state.testMatrix}>Export</CSVLink>
                </div>
                <CSVReader label="Load from *.csv " inputId={"csvMatrix"} onFileLoaded={this.handleFileData} parseOptions={this.parseOptions} />
            </div>
        );
    }

    rotateClockWise = async () => {
        await fetch('api\\matrix\\clockwise-rotation')
            .then(res => (res.ok ? res : Promise.reject(res)))
            .then(res => res.json())
            .then(res => this.setState({ testMatrix: res, loading: false }));
    }

    rotateAntiClockWise = async () => {
        await fetch('api\\matrix\\anti-clockwise-rotation')
            .then(res => (res.ok ? res : Promise.reject(res)))
            .then(res => res.json())
            .then(res => this.setState({ testMatrix: res, loading: false }));
    }

    generate = () => {
        var rows = this.state.row;
        var columns = this.state.col;
        if (this.isUserDataValid(rows, columns) === true) {
            var customMatrix = this.buildRandomMatrix(rows, columns);
            this.post(customMatrix);
            this.setState({ testMatrix: customMatrix, loading: false });
        }
        else {
            alert("Please, use square matrix, at least 2x2.");
        }
    }

    async post(matrix) {
        await fetch('api\\matrix\\store',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ matrix: matrix })
            })
            .then(res => (res.ok ? res : Promise.reject(res)))
            .then(res => res.json());
    }

    handleRowColCount = (e) => {
        this.setState({ row: e.target.value, col: e.target.value});
    }

    //demo
    handleFileData = (data, fileName) => {
        var csvMatrix = this.mapStringToInt(data);
        this.setState({ testMatrix: csvMatrix, loading: false });
        this.post(this.state.testMatrix);
    }

    // service handlers
    buildRandomMatrix = (row, col) => {
        var randomMatrix = new Array(col);

        for (let i = 0; i < row; i++) {
            randomMatrix[i] = new Array(i);
        }

        for (let matrixRow = 0; matrixRow < row; matrixRow++) {
            for (let matrixColumn = 0; matrixColumn < col; matrixColumn++) {
                randomMatrix[matrixRow][matrixColumn] = this.generateRandomNumber();
            }
        }
        return randomMatrix;
    }

    mapStringToInt = (data) => {
        var csvMatrix = new Array(data.length);

        for (let i = 0; i < data.length; i++) {
            csvMatrix[i] = new Array(data.length);
        }

        for (let matrixRow = 0; matrixRow < data.length; matrixRow++) {
            for (let matrixColumn = 0; matrixColumn < data.length; matrixColumn++) {
                csvMatrix[matrixRow][matrixColumn] = parseInt(data[matrixRow][matrixColumn], 10);
            };
        }

        return csvMatrix;
    }

    generateRandomNumber() {
        var digit = Math.floor(Math.random() * 900) + 100;
        return digit;
    }

    isUserDataValid(row, col) {
        var r = parseInt(row, 10);
        var c = parseInt(col, 10);
        var t = (r === c && r >= this.defaultMatrixRowCount);
        return t;
    }
}