<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsExamPeopleCountRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:decimal-format name="format1" grouping-separator=" " decimal-separator=","/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h3 align="center">
						<span>
							<xsl:text>Входни параметри на Справка по ЕИК и период за брой обучени лица в център за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.</xsl:text>
						</span>
					</h3>
					<br/>
					<xsl:for-each select="n1:PermitsExamPeopleCountRequest">
						<br/>
						<table style="width:80%; " align="left" border="0" width="100%">
							<tbody>
								<tr>
									<td width="365">
										<span style="font-style:italic; ">
											<xsl:text>ЕИК/БУЛСТАТ</xsl:text>
										</span>
									</td>
									<td align="left">
										<xsl:for-each select="n1:IdentNumber">
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td align="left" width="365">
										<span style="font-style:italic; ">
											<xsl:text>Начална дата на период за търсене</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>&#160;</xsl:text>
										</span>
									</td>
									<td align="left">
										<xsl:for-each select="n1:DateFrom">
											<span style="font-style:italic; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
											</span>
											<span style="font-style:italic; ">
												<xsl:text> г.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td align="left" width="365">
										<span style="font-style:italic; ">
											<xsl:text>Крайна дата на период за търсене</xsl:text>
										</span>
									</td>
									<td align="left">
										<xsl:for-each select="n1:DateTo">
											<span style="font-style:italic; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
											</span>
											<span style="font-style:italic; ">
												<xsl:text> г</xsl:text>
											</span>
											<span>
												<xsl:text>.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
						<br/>
						<br/>
						<br/>
						<br/>
						<br/>
					</xsl:for-each>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
