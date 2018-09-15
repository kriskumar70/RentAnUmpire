const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: './src/main.ts',

  module: {
    rules: [
        {
            test: /\.ts$/,
            use: ['ts-loader', 'angular2-template-loader'],
            exclude: /node_modules/
        },
        {
            test: /\.(html|css)$/,
            include: [/node_modules.jqwidgets-framework/, /ClientApp/],
           // path.resolve(__dirname, , './node_modules/jqwidgets-framework/',
            loader: 'raw-loader'
            // loader: `babel-loader?${JSON.stringify(babelConfig)}`
        }
    ]
  },
  resolve: {
    extensions: ['.ts', '.js']
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './src/index.html',
      filename: 'index.html',
      inject: 'body'
    }),
    new webpack.DefinePlugin({
      // global app config object
      config: JSON.stringify({
        apiUrl: 'http://localhost:4000/api'
      })
    })
  ],
  optimization: {
    splitChunks: {
      chunks: 'all',
    },
    runtimeChunk: true
  },
  devServer: {
    historyApiFallback: true
  }
};