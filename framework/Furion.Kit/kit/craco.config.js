const { addAfterLoader, loaderByName } = require("@craco/craco");

module.exports = async () => {
  const remarkGfm = (await import("remark-gfm")).default;
  const remarkMath = (await import("remark-math")).default;
  const remarkFrontmatter = (await import("remark-frontmatter")).default;
  const rehypeKatex = (await import("rehype-katex")).default;

  return {
    webpack: {
      configure: (webpackConfig) => {
        addAfterLoader(webpackConfig, loaderByName("babel-loader"), {
          test: /\.(md|mdx)$/,
          loader: require.resolve("@mdx-js/loader"),
          /** @type {import('@mdx-js/loader').Options} */
          options: {
            remarkPlugins: [remarkGfm, remarkMath, remarkFrontmatter],
            rehypePlugins: [rehypeKatex],
          },
        });
        return webpackConfig;
      },
    },
  };
};
