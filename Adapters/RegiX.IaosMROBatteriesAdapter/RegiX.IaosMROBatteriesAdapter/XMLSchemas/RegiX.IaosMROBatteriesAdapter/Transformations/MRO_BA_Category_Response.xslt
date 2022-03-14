<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAOS/MROBatteries/CategoryResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h2 align="center">
						<span>
							<xsl:text>Справка за вид батерии и акумулатори по ЕИК в Регистър на лицата, които пускат на пазара батерии и акумулатори, включително вградени в уреди и моторни превозни средства. - резултат</xsl:text>
						</span>
					</h2>
					<br/>
					<br/>
					<table style="width:65%; " align="center" border="0" width="100%">
						<tbody>
							<tr>
								<th>
									<span>
										<xsl:text>Регистрационен номер</xsl:text>
									</span>
								</th>
								<td>
									<xsl:for-each select="n1:MRO_BA_Category_Response">
										<xsl:for-each select="n1:Authorization">
											<xsl:for-each select="n1:AuthNum">
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<th>
									<span>
										<xsl:text>Наименование на организацията</xsl:text>
									</span>
								</th>
								<td>
									<xsl:for-each select="n1:MRO_BA_Category_Response">
										<xsl:for-each select="n1:Authorization">
											<xsl:for-each select="n1:CompanyName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<th height="27">
									<span>
										<xsl:text>Вид батерии и акумулатори:</xsl:text>
									</span>
								</th>
								<td>
									<ul>
										<xsl:for-each select="n1:MRO_BA_Category_Response">
											<xsl:for-each select="n1:Authorization">
												<xsl:for-each select="n1:BACategories">
													<xsl:for-each select="n1:BACategory">
														<li>
															<span style="border-top-width:25px; ">
																<xsl:apply-templates/>
															</span>
														</li>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</ul>
								</td>
							</tr>
						</tbody>
					</table>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
