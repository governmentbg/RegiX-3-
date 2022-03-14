<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsInstructorsReportRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<h3 align="center">
						<span>
							<xsl:text>Входни параметри на Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им </xsl:text>
						</span>
					</h3>
					<br/>
					<table align="left" border="0">
						<tbody>
							<tr>
								<th>
									<span>
										<xsl:text>ЕГН на търсеният преподавател:</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:PermitsInstructorsRequest">
									<td>
										<xsl:for-each select="n1:SubjectIdentNumber">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</xsl:for-each>
							</tr>
						</tbody>
					</table>
					<br/>
				</xsl:for-each>
				<br/>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>